    void DisableButtons()
    {
        for(int i = 0; i < Resources.Count; i ++)
        {
            var btn = Resources[i] as Button;
            if(btn != null)
            {
                btn.IsEnabled = false;
            }
        }
    }
