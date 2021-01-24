    using System;
    using System.Text;
    
    namespace _ {
      class Q {
        public static void Main(string[] args) {
          string str = @"\u0006\u0001\0d\o?\""\0$?##STA\r\nSystemLevel:Run\r\nstatus:1\r\nSensor Value:12.45\r\n................\r\nSTOP##";
          byte[] bts = Encoding.UTF8.GetBytes(str);
          var g23to40 = getRange(bts, 22, 39);
          Console.WriteLine(Encoding.UTF8.GetString(g23to40));
        }
        public static byte[] getRange(byte[] a, int s, int e = -1) {
          if (e == -1) { e = a.Length-1; }
          if (e <= s) { return new byte[]{}; }
          byte[] r = new byte[e-s];
          int bi = 0;
          for (int i = s; i != e; i++) {
            if (i >= s && i <= e) {
              r[bi] = a[i];
              bi++;
            }
          }
          return r;
        }
      }
    }
