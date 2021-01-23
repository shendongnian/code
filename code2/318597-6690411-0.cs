    void TypeView_NodeMouseClick(object sender, TreeNodeMouseClickEvenArgs e)
    {     
        DoWhateverAfterMouseClicked<string>(sender, e);    
    }
    
    public void DoWhateverAfterMouseClicked<T>(object sender, TreeNodeClickEventArgs e)
    {    
               if ((typeSelected != null) && (e.Node.Tag is T))
                        typeSelected((T)e.Node.Tag);
    
    }
