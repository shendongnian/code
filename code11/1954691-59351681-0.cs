IEnumerator GetInputFromUser()
{
    while (timer < timeSetInStart)
    {
         If(Input.GetKeyDown(KeyCode.Space))
         {    
             print("IN";
             yield break;
         }
         else
         {
             yield return null;
         }
    }
}
