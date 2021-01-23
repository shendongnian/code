    bool ButtonEnabled = (Something > 0);
    
    btnOne.Enabled = ButtonEnabled ? true : btnOne.Enabled;
    btnTwo.Enabled = ButtonEnabled ? true : btnTwo.Enabled;
    btnThree.Enabled = !ButtonEnabled ? false : btnThree.Enabled;
    btnFour.Enabled = !ButtonEnabled ? false : btnFour.Enabled;
