public void Clicked()
{
    Loading.SetActive(true);
    StartCoroutine(FetchAndDisableLoading());
}
IEnumerator FetchAndDisableLoading(){
    //Rest of code fetching data from api using UnityEngine.Networking
    //If you make a UnityWebRequest here you should do:
    //yield return webRequest.SendWebRequest();
    //This will wait for the web request to finish before proceeding
    //Finally, when all code is executed you should disable the object:
    if(condition)
    {
        Loading.SetActive(false);
       //Redirect to another page
    }
}
