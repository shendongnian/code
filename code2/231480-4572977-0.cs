    using System;
    
    namespace WindowsFormsApplication1 {
        static class Program {
            [STAThread]
            static void Main() {
                Van van = new Van();
                string status = van.GetStatus();
            }
        }
    
        public static class VanExtension {
            public static string GetStatus(this Van van) {
                if(van.is_offline == 1) {
                    return "Offline";
                }
                else if(van.is_prayer_room == 1) {
                    return "In Prayer Room";
                }
    
                return "TODO:  Create statuses";
            }
        }
    
        public class Van {
            public int is_offline { get; set; }
            public int is_prayer_room { get; set; }
        }
    }
