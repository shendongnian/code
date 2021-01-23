    string x = "asdf";
    unsafe {
      fixed (char* s = x) {
        char* p = s;
        for (int i = 0; i < 4; i++) {
          Console.WriteLine(*p);
          p++;
        }
      }
    }
