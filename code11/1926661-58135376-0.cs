    public class ClassIAmTesting
    {
        //Have a Func to fetch a file manager...
        private Func<IFileTransferManager> _filemgr = null;
        //Have a property which we'll use in this class to get the File manager
        public Func<IFilterTransferManager> GetFileManager
        {
            get
            {
                //If we try to use this property for the first time and it's not set,
                //then set it to the default implementation.
                if (_fileMgr == null)
                {
                    _fileMgr = () => IoC.Get<IFileTransferManager>();
                }
                return _fileMgr;
            }
            set
            {         
                //allow setting of the function which returns an IFileTransferManager
                if (_fileMgr == null)
                {
                    _fileMgr = value;
                }
            }
        }
        //this is the method you ultimately want to test...
        public async Task<bool> SomeMethodIAmTesting()
        {
            //don't do this any more:
            //_fileTransferManager = IoC.Get<IFileTransferManager>();
            
            //instead do this.
            _fileTransferManager = GetFileManager();
            await _fileTransferManager
                .UploadFile(connection, file.FullName, destinationPath)
                .ConfigureAwait(false);
            return true;
        }
    }
