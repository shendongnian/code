    private void RevertToPreviousState()
            {
                Memento memento = (Memento)_caretaker.GetMemento(--_currentStateIndex);
                string[] state = (string[]) memento.GetState();
                TextBox1.Text = state[0];
                TextBox2.Text = state[1];//expand as needed
            }
