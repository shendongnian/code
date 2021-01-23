    public class notepad_check_class
    {
        public static Process[] notepad_list;
        public static bool notepad_running;
        public static void notepad_check()
        {
            notepad_list = Process.GetProcessesByName("notepad");
            notepad_running = notepad_list.Length > 0;
        }
    }
    public class kill_notepad_class
    {
        public static void kill_notepad()
        {
            notepad_check_class.notepad_check();
            if (notepad_check_class.notepad_running)
            {
                if (MessageBox.Show("Are you sure you want to kill all notepad processes?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    foreach (Process notepad_process in notepad_check_class.notepad_list)
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
