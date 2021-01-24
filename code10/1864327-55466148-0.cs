    using System.IO;
    
    public class MyClass
    {
        private Stream _stream;
    
        private void OnDisable()
        {
            _stream?.Dispose();
        }
    
        private void OnEnable()
        {
            _stream = File.OpenRead("file.txt");
        }
    
        private void Update()
        {
            if (_stream != null)
            {
                // do something with it
            }
        }
    }
