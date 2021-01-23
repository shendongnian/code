    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Org.BouncyCastle.Cms;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.X509;
    
    namespace ConsoleApplicationSignWithBouncyCastle
    {
        class Program
        {
    
            [STAThread]
            static void Main(string[] args)
            {
    
                try
                {
                    // First load a Certificate, filename/path and certificate password
                    Cert = ReadCertFromFile("./test.pfx", "test");
    
                    //  Select a binary file
                    var dialog = new OpenFileDialog
                                     {
                                         Filter = "All files (*.*)|*.*",
                                         InitialDirectory = "./",
                                         Title = "Select a text file"
                                     };
                    var filename = (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : null;
    
                    // Get the file
                    var f = new FileStream(filename, System.IO.FileMode.Open);
    
                    // Reading through this code stub to be sure I get it all :-)  [ Different subject entirely ]
                    var fileContent = ReadFully(f);
    
                    // Create the generator
                    var dataGenerator = new CmsEnvelopedDataStreamGenerator();
    
                    // Add receiver
                    // Cert is the user's X.509 Certificate set bellow
                    dataGenerator.AddKeyTransRecipient(Cert);
    
                    // Make the output stream
                    var outStream = new FileStream(filename + ".p7m", FileMode.Create);
    
                    // Sign the stream
                    var cryptoStream = dataGenerator.Open(outStream, CmsEnvelopedGenerator.Aes128Cbc);
    
                    // Store in our binary stream writer and write the signed content
                    var binWriter = new BinaryWriter(cryptoStream);
                    binWriter.Write(fileContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("So, you wanna make an exception huh! : " + ex.ToString());
                    Console.ReadKey();
                }
            }
    
            public static byte[] ReadFully(Stream stream)
            {
                stream.Seek(0, 0);
                var buffer = new byte[32768];
                using (var ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = stream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            return ms.ToArray();
                        ms.Write(buffer, 0, read);
                    }
                }
            }
    
            public static Org.BouncyCastle.X509.X509Certificate Cert { get; set; }
    
            // This reads a certificate from a file.
            // Thanks to: http://blog.softwarecodehelp.com/2009/06/23/CodeForRetrievePublicKeyFromCertificateAndEncryptUsingCertificatePublicKeyForBothJavaC.aspx
            public static X509Certificate ReadCertFromFile(string strCertificatePath, string strCertificatePassword)
            {
                try
                {
                    // Create file stream object to read certificate
                    var keyStream = new FileStream(strCertificatePath, FileMode.Open, FileAccess.Read);
    
                    // Read certificate using BouncyCastle component
                    var inputKeyStore = new Pkcs12Store();
                    inputKeyStore.Load(keyStream, strCertificatePassword.ToCharArray());
    
                    //Close File stream
                    keyStream.Close();
    
                    var keyAlias = inputKeyStore.Aliases.Cast<string>().FirstOrDefault(n => inputKeyStore.IsKeyEntry(n));
    
                    // Read Key from Alieases  
                    if (keyAlias == null)
                        throw new NotImplementedException("Alias");
    
                    //Read certificate into 509 format
                    return (X509Certificate)inputKeyStore.GetCertificate(keyAlias).Certificate;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("So, you wanna make an exception huh! : " + ex.ToString());
                Console.ReadKey();
                return null;
            }
        }
    } }
