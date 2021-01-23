    protected override void OnKeyPress(KeyPressEventArgs e){
        if(!char.IsControl(e.KeyChar)){
            // do something with printable character
        }
    }
