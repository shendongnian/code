    using System;
    using System.IO;
    
    namespace fileFotFoundException {
        public abstract class MyFile {
    
            protected MyFile(String fullPathToFile) {
                if (!File.Exists(fullPathToFile)) throw new FileNotFoundException();
            }
        }
    }
    
    namespace fileFotFoundExceptionTests {
        using fileFotFoundException;
        using NUnit.Framework;
    
        public class SubClass : MyFile {
            public SubClass(String fullPathToFile) : base(fullPathToFile) {
                // If we have to have it as an abstract class...
            }
        }
    
        [TestFixture]
        public class MyFileTests {
    
            [Test]
            public void MyFile_CreationWithNonexistingPath_ExceptionThrown() {
                const string nonExistingPath = "C:\\does\\not\\exist\\file.ext";
    
                Assert.Throws<FileNotFoundException>(() => new SubClass(nonExistingPath));
            }
        }
    }
