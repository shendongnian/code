            void StaticTick(object o, EventArgs sender)
            {
                GC.Collect();
                memoryuseage.Text = GC.GetTotalMemory(true).ToString();
            }
