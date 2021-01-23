    private void FlowerButtonClick()
    {
       //When this button is clicked, change the displayed image to a flower picture
       UpdateDisplayedImage(PartyImage.Flower);   
    }
    //etc.
    public void UpdateDisplayedImage(PartyImage image)
    {
        //Determine the image that was specified in the parameter,
        //and update my picture box accordingly
        switch (PartyImage)
        {
        	case None:
                myPicBox.Image = null;
        		break;
        	case Smileyface:
                myPicBox.Image = MyWindowsApp.Properties.Resources.SmileyFace;
        		break;
        	case Flower:
                myPicBox.Image = MyWindowsApp.Properties.Resources.Flower;
        		break;
        	case Balloon:
                myPicBox.Image = MyWindowsApp.Properties.Resources.Balloon;
        		break;
        }
    }
