    //css_nuget dotnetzip
    using Ionic.Zip;
    using System;
 
    class Script
    {
        static public void Main()
        {
            using(ZipFile zip = new ZipFile())
            {
                zip.AddFile("app.exe");
                zip.AddFile("readme.exe");
                zip.Save("app.zip");
            }
        }
    }
