void OnTriggerEnter2D(Collider2D other)
{
   if (other.tag == "(your tag)")
   {
    StartCoroutine(name());
   }
}
within our IEnumerator is where we wait the number of seconds with the WaitForSeconds() instance. wait as many seconds as you want before sending it back into action
IEnumerator name()
{
     yield return new WaitForSeconds(4);
     func();
}
four seconds after colliding with an object, we call a response.
void func()
{
//execute four seconds later
}
Altogether, looking like:
NewBehaviorScript:learning()
{
   void start()
   {
   //N/A
   }
   void Update()
   {
   //N/A
   }
      void OnTriggerEnter2D(Collider2D other)
      {
         if (other.tag == "(your tag)")
         {
          StartCoroutine(NAME());
         }
       }
      IEnumerator NAME()
      {
           yield return new WaitForSeconds(4);
           func();
      }
      void func()
      {
   //execute reaction
      }
}
