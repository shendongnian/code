    private void tvwACH_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
    {
         string strFile = string.Empty;
    
         // the problem is here, root node does not have a parent
         // also added a fix
         if (e.Node.Parent != null && e.Node.Parent.Text == "FileHeader")
         {
              strFile = e.Node.ToString();
        
              string str = strFile.Substring(10);
              StringComparison compareType = StringComparison.InvariantCultureIgnoreCase;
              string fileName = Path.GetFileNameWithoutExtension(str);
              string extension = Path.GetExtension(str);
              if (extension.Equals(".txt", compareType))
              {
                  StringBuilder osb = new StringBuilder();
                  objFileHeader.getFileHeader(str, out osb);
                  e.Node.ToolTipText = Convert.ToString(osb);
              }
         }
    }
