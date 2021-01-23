    List<String> CheckedNames( System.Windows.Forms.TreeNodeCollection theNodes)
    {
        List<String> aResult = new List<String>();
    
        if ( theNodes != null )
        {
            foreach ( System.Windows.Forms.TreeNode aNode in theNodes )
            {
                if ( aNode.Checked )
                {
                    aResult.Add( aNode.Text );
                }
    
                aResult.AddRange( CheckedNames( aNode.Nodes ) );
            }
        }
    
        return aResult;
    }
