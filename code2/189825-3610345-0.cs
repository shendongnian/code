    m_button.Click += delegate { Console.Write("here"); }
    ...
    // Fail
    m_button.Click -= delegate { Console.Write("here"); } 
    EventHandler del = delegate { Console.Write("here"); }
    m_button.Click += del;
    ...
    m_button.Click -= del;
