    private static void WriteToFile2() {
        using (FileStream s = ...) { WriteToStream(s); }
    }
    private static void WriteToMemory() {
        using (MemoryStream s = ...) { WriteToStream(s); }
    }
    private static void WriteToStrem(Stream s) {
        ...
    }
    public void ProcessFile() {
        using (FileStream s = ...) { // file 1
            ...
            if (...) {
                WriteToFile2();
            } else {
                WriteToMemory();
            }
        }
    }
