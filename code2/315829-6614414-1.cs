    using System.IO;
    class Foo {
        string Bar() {
            return File.Exists("path").ToString();
        }
    }
