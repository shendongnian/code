        private void Form1_Resize(object sender, EventArgs e)
        {
            int w = MainPanel.Width; // you can use form.width when you don't use panels
           
            w = (w - 120)/4; // 120 because set 15px for each side of panels
                             // and put panels in FlowLayoutPanel
                             // 4 because i have 4 panel boxes
            panel1.Width = w;
            panel2.Width = w;
            panel3.Width = w;
            panel4.Width = w;
        }
