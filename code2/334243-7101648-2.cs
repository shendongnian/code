    private void SaveMemento()
    {
                Memento memento = new Memento();
                string[] state = {TextBox1.Text, TextBox2.Text};//expand as needed
                memento.SetState(state);
                _caretaker.AddMemento(_currentStateIndex, memento);
                _currentStateIndex++;
    }
