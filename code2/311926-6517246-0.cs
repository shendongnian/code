    using System.Diagnostics;
    
    private void button1_Click(object sender, EventArgs e)
    {
        Debug.Assert(Alligor > 0.0);
        Debug.Assert(AlligorInput > 0.0);
    
        costofAlligor = Alligor * AlligorInput;
    
        Debug.Assert(costofAlligor > 0.0);
        ...
    }
