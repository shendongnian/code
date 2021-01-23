    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    //References -> Add Reference -> "System.Runtime.Serialization" Add
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    
    namespace test {
        class Program {
            [DataContract]
            public class Mdata {
                [DataMember(Name = "homepage")] 
                public String homepage { get; private set; }
                [DataMember(Name = "homepage_is_newtabpage")]
                public Boolean isNewTab { get; private set; }
                public Mdata() { }
                public Mdata(String data) {
                    homepage = data;
                }
            }
    
            public static Mdata FindData(String json) {
                Mdata deserializedData = new Mdata();
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedData.GetType());
                deserializedData = ser.ReadObject(ms) as Mdata;
                ms.Close();
                return deserializedData;
            }
    
            static void Main(string[] args) {
                const int LikeWin7 = 6;
                OperatingSystem osInfo = Environment.OSVersion;
                DirectoryInfo strDirectory;
                String path=null, file=null, data;
    
                if (osInfo.Platform.Equals(System.PlatformID.Win32NT))
                    if (osInfo.Version.Major == LikeWin7)
                        path = Environment.GetEnvironmentVariable("LocalAppData") +
                            @"\Google\Chrome\User Data\Default";
                if (path == null || path.Length == 0)
                    throw new ArgumentNullException("Fail. Bad OS.");
                if (!(strDirectory = new DirectoryInfo(path)).Exists)
                    throw new DirectoryNotFoundException("Fail. The directory was not fund");
                if (!new FileInfo(file = Directory.GetFiles(strDirectory.FullName, "Preferences*")[0]).Exists)
                    throw new FileNotFoundException("Fail. The file was not found.", file);
    
                Mdata info = FindData(data = System.IO.File.ReadAllText(file));
                Console.WriteLine(info.homepage);
                Console.WriteLine(info.isNewTab);
            }
        }
    }
