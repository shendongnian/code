        public string TextBoxHint
        {
            get 
            { 
                return toolTip1.GetToolTip(textBox1); 
            }
            set
            {
                toolTip1.SetToolTip(textBox1, value);                
            }
        }
