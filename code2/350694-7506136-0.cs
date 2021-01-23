    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Windows.Forms;
    using System.Reflection;
    using EmbeddedReference; // Hard reference with Copy Local = False
    namespace EmbeddedReferenceApplication {
        class Program {
            static void Main(string[] args) {
                AppDomain.CurrentDomain.AssemblyResolve += AppDomain_AssemblyResolve;
                MyMain();
            }
            private static void MyMain() {
                EmbeddedReference.MessageHelper.ShowMessage();
            }
            private static Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
                string manifestResourceName = "EmbeddedReferenceApplication.EmbeddedReference.dll"; // You can also do Assembly.GetExecutingAssembly().GetManifestResourceNames();
                string path = Path.Combine(Application.StartupPath, manifestResourceName.Replace("EmbeddedReferenceApplication.", ""));
                ExtractEmbeddedAssembly(manifestResourceName, path);
                Assembly resolvedAssembly = Assembly.LoadFile(path);
                return resolvedAssembly;
            }
            private static void ExtractEmbeddedAssembly(string manifestResourceName, string path) {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(manifestResourceName)) {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    using (FileStream fstream = new FileStream(path, FileMode.Create)) {
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
