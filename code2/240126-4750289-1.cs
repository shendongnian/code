    private void btnAccel_Click(object sender, EventArgs e)
    {
        lblStatus.Text = plane.speed.ToString();
        plane.PlanePosition.speed = double.Parse(txtSpeed.Text);
        plane.Accelerate();
        lblStatus.Text = plane.PlanePosition.speed.ToString();        
    
    }
