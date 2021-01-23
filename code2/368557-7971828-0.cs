    // specifically typecasting the TYPE of form being passed in, 
    // not just a generic form.  We need to see the exposed elements
    Form1 CalledFrom;
    // Ensure to do the : this() to make sure default behavior
    // to initialize the controls on the form are created too.
    public Form2(Form1 viaParameter) : this()
    {
      CalledFrom = viaParameter;
    }
    
    private void btnOnForm2_Click(object sender, EventArgs e)
    {
      CalledFrom.ValuesByProperty = this.txtOnForm2.Text;
      MessageBox.Show( "Check form 1 textbox" );
    
      string GettingBack = CalledFrom.ValuesByProperty;
      MessageBox.Show( GettingBack );
    
      CalledFrom.SetViaMethod( "forced value, not from textbox" );
      MessageBox.Show( "Check form 1 textbox" );
    
      GettingBack = CalledFrom.GetViaMethod();
      MessageBox.Show( GettingBack );
    }
