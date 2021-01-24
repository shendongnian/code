var VB1 = GameObject.Find("VB1");
var VB2 = GameObject.Find("VB2");
var VB3 = GameObject.Find("VB3");
if(VB1 != null && VB2 != null && VB3 != null){
  
    VB1.GetComponent<VirtualButtonBehavior>().enabled = false;
    VB2.GetComponent<VirtualButtonBehavior>().enabled = false;
    VB3.GetComponent<VirtualButtonBehavior>().enabled = false;
}
Now to integrate the above to your code, perhaps under `OnButtonPressed()` function; you can add:
public void OnButtonPressed(VirtualButtonBehaviour vb)
{
    vbName = vb.VirtualButtonName;
        if (vbName == "VB1")
        {
         Debug.Log("Button 1 is pressed!");
         audi.Play();
         vb.GetComponent<VirtualButtonBehaviour>().enabled = false;
         DeactivateButtons();
        }
        else if (vbName == "VB2")
        {
            Debug.Log("Button 2 is pressed!");
            audi.Play();
            vb.GetComponent<VirtualButtonBehaviour>().enabled = false;
            DeactivateButtons();
        }
        else 
        {
            Debug.Log("Button 3 is pressed!");
            audi.Play();
            vb.GetComponent<VirtualButtonBehaviour>().enabled = false;
            DeactivateButtons();
        }
}
public void DeactivateButtons()
{
   var VB1 = GameObject.Find("VB1");
   var VB2 = GameObject.Find("VB2");
   var VB3 = GameObject.Find("VB3");
   if(VB1 != null && VB2 != null && VB3 != null){
  
      VB1.GetComponent<VirtualButtonBehavior>().enabled = false;
      VB2.GetComponent<VirtualButtonBehavior>().enabled = false;
      VB3.GetComponent<VirtualButtonBehavior>().enabled = false;
   }
}
