    private int count = 0;
    public void ChangeClassButton()
    {
        Debug.Log("Skiftede klasse");
        if(!changeClassBool){
        {
            Debug.Log(activeDrum[count]);
            changeClassText.text = activeDrum[count];
            OscMessage oscM = Osc.StringToOscMessage("/changeClass" + count);
            Debug.Log(Osc.OscMessageToString(oscM));
            oscHandler.Send(oscM);
            changeClassBool = true;
            if (count >= activeDrum.Length)
            {
                count = 0;
            } else{
                count++;
            }
        }
    }
