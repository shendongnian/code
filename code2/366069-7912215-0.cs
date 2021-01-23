        Stack<Button[,]> stack = new Stack<Button[,]>();
        private void button4_Click(object sender, EventArgs e)
        {
            Button[,] buttons = new Button[2, 2] { { button1, button2 }, { button3, button4 } };
            stack.Push((Button[,])buttons.Clone());
            buttons[0, 0] = button2;
            buttons[0, 1] = button1;
            stack.Push((Button[,])buttons.Clone());
            buttons[1, 0] = button4;
            buttons[1, 1] = button3;
            stack.Push((Button[,])buttons.Clone());
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                Button[,] buttons = stack.Pop();
                txtButtonOrder.Text = buttons[0, 0].Text + buttons[0, 1].Text + buttons[1, 0].Text + buttons[1, 1].Text;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
