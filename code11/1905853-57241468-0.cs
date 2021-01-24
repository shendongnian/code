     public class Script1 : MonoBehaviour 
     {
         public List<string> testList = new List<string>();
     
         void Start()
         {
             testList.Add ("Item 1");
             testList.Add ("Item 2");
             testList.Add ("Item 3");
         }
     }
     public class Script2 : MonoBehaviour 
     {
         Script1 s1;
     
         IEnumerator Start()
         {
             s1 = GetComponent<Script1>();
             yield return new WaitForEndOfFrame();
             foreach(string s in s1.testList)
                 print (s);
         }
     }
