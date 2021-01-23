     private void textBoxExpression_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                m_Host.ShortCut(sender, e, textBoxExpression);
            }
            else
            {
                   ....
            }
    }
