c#
private void timer3_Tick(object sender, EventArgs e)
    {
var maxsheet=30; //write correct!
bool processed=false;
while(totalsheetcount<maxsheet)
{
        chksignal_robot(); //keep checking signal           
        if (textBox8.Text.Contains("process")) //
        {
            totalsheetcount++;
            grab_image();
            Thread.Sleep(200);               
            if(!processed)
             processimage(); 
            processed=true;   
        }
}
    }
