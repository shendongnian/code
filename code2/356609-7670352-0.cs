        private const int _maxCapacity = 10000;
    
        private Queue<string> _messageQueue = new Queue<string>(_maxCapacity);
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (_messageQueue.Count >= _maxCapacity)
            {
                _messageQueue.Dequeue();
            }
        
            _messageQueue.Enqueue("message " + _count++.ToString());
        
            richTextBox1.Lines = _messageQueue.ToArray();
        }
