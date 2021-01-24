    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.IO.Compression;
    using System.Xml.Linq;
    using System.IO.Packaging;
    using System.Text;
    namespace MyApp {
        class Program {
            private const int FIELDS_LENGTH = 4;
            static void Main(string[] args) {
                if (args.Length != 1) {
                    Console.WriteLine("specify one directory to update");
                }
                if (!Directory.Exists(args[0])) {
                    Console.WriteLine("directory does not exist");
                }
                IEnumerable<FileInfo> files = Directory.GetFiles(args[0]).Where(x => Path.GetExtension(x) == ".xlsx").Select(x => new FileInfo(x));
                foreach (FileInfo file in files) {
                    using (FileStream fileStream = File.Open(file.FullName, FileMode.OpenOrCreate)) {
                        using (ZipArchive archive = new ZipArchive(fileStream, ZipArchiveMode.Update)) {
                            ZipArchiveEntry entry = archive.GetEntry("customXml/item1.xml");
                            IEnumerable<byte> bytes;
                            using (Stream entryStream = entry.Open()) {
                                XDocument doc = XDocument.Load(entryStream);
                                byte[] dataMashup = Convert.FromBase64String(doc.Root.Value);
                                int version = BitConverter.ToUInt16(dataMashup.Take(FIELDS_LENGTH).ToArray(), 0);
                                int packagePartsLength = BitConverter.ToUInt16(dataMashup.Skip(FIELDS_LENGTH).Take(FIELDS_LENGTH).ToArray(), 0);
                                byte[] packageParts = dataMashup.Skip(FIELDS_LENGTH * 2).Take(packagePartsLength).ToArray();
                                int permissionsLength = BitConverter.ToUInt16(dataMashup.Skip(FIELDS_LENGTH * 2 + packagePartsLength).Take(FIELDS_LENGTH).ToArray(), 0);
                                byte[] permissions = dataMashup.Skip(FIELDS_LENGTH * 3).Take(permissionsLength).ToArray();
                                int metadataLength = BitConverter.ToUInt16(dataMashup.Skip(FIELDS_LENGTH * 3 + packagePartsLength + permissionsLength).Take(FIELDS_LENGTH).ToArray(), 0);
                                byte[] metadata = dataMashup.Skip(FIELDS_LENGTH * 4 + packagePartsLength + permissionsLength).Take(metadataLength).ToArray();
                                int permissionsBindingLength = BitConverter.ToUInt16(dataMashup.Skip(FIELDS_LENGTH * 4 + packagePartsLength + permissionsLength + metadataLength).Take(FIELDS_LENGTH).ToArray(), 0);
                                byte[] permissionsBinding = dataMashup.Skip(FIELDS_LENGTH * 5 + packagePartsLength + permissionsLength + metadataLength).Take(permissionsBindingLength).ToArray();
                                // use double memory stream to solve issue as memory stream will change
                                // size when re-saving the data mashup object
                                using (MemoryStream packagePartsStream = new MemoryStream(packageParts)) {
                                    using (MemoryStream ms = new MemoryStream()) {
                                        packagePartsStream.CopyTo(ms);
                                        using (Package package = Package.Open(ms, FileMode.Open, FileAccess.ReadWrite)) {
                                            PackagePart section = package.GetParts().Where(x => x.Uri.OriginalString == "/Formulas/Section1.m").FirstOrDefault();
                                            string query;
                                            using (StreamReader reader = new StreamReader(section.GetStream())) {
                                                query = reader.ReadToEnd();
                                                // do other replacing, removing of query here
                                                query = query.Replace("old-server", "new-server");
                                            }
                                            using (BinaryWriter writer = new BinaryWriter(section.GetStream())) {
                                                writer.Write(Encoding.ASCII.GetBytes(query));
                                            }
                                        }
                                        packageParts = ms.ToArray();
                                    }
                                    bytes = BitConverter.GetBytes(version)
                                                .Concat(BitConverter.GetBytes(packageParts.Length))
                                                .Concat(packageParts)
                                                .Concat(BitConverter.GetBytes(permissionsLength))
                                                .Concat(permissions)
                                                .Concat(BitConverter.GetBytes(metadataLength))
                                                .Concat(metadata)
                                                .Concat(BitConverter.GetBytes(permissionsBindingLength))
                                                .Concat(permissionsBinding);
                                    doc.Root.Value = Convert.ToBase64String(bytes.ToArray());
                                    entryStream.SetLength(0);
                                    doc.Save(entryStream);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
