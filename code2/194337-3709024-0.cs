    class MyFileStream {
        FileStream fs;
        private MyFileStream(string filename, FileMode mode) {
            fs = new FileStream(filename, FileMode.Open);
        }
        private void Dispose() {
            fs.Dispose();
        }
        public static void Using(string filename, FileMode mode, Action<MyFileStream> use) {
            MyFileStream mfs = new MyFileStream(filename, mode);
            use(mfs);
            mfs.Dispose();
        }
        public void Read(...) { ... }
    }
