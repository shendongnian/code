        process.EnableRaisingEvents = true;
        process.Exited += Proc_Exited;
        private void Proc_Exited(object sender, EventArgs e)
        {
            // Code to handle process exit
        }
