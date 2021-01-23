     public class notepad_check_class
        {
            public int notepad_running;
            public static void notepad_check()
            {
                Process [] notepad_list = Process.GetProcessesByName("notepad");
                if (notepad_list.Length > 0)
                {
                    notepad_running = 1;
                }
            }
        }
    
        public class kill_notepad_class
        {
            public notepad_check_class npc;
            public kill_notepad_class() {
               npc = new notepad_check_class();
            }
            public static void kill_notepad()
            {
                notepad_check_class.notepad_check();
                if (npc.notepad_running = 1)
                {
                    if (MessageBox.Show("Are you sure you want to kill all notepad processes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        foreach (Process notepad_process in notepad_list)
                        {
                            notepad_process.Kill();
                        }
                    return;
                }
                else
                {
                    MessageBox.Show("Cannot find any running process of notepad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
