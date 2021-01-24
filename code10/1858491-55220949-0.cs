    `using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class test : MonoBehaviour
    {
        public Text playerDisplay;
        public Text score;
        public Button submit;
        public InputField nameField;
        public GameObject bb;
        public Text Error;
    
        public void CallLogIn()
        {
            StartCoroutine(Loginplayer());
        }
    
        IEnumerator Loginplayer()
        {
            WWWForm form = new WWWForm();
            form.AddField("name", nameField.text);
    
    
            WWW www = new WWW("http://192.168.1.100/sqlconnect/test.php", form);
            yield return www;
            if (www.text[0] == '0')
            {
    
                DBManager.username = nameField.text;
                DBManager.score = int.Parse(www.text.Split('\t')[1]);
    
                playerDisplay.text = "player: " + DBManager.username;
                score.text = "score: " + DBManager.score;
    
                bb.SetActive(true);
            }
            else
            {
                Error.text = "save failes. Error #" + www.error;
                bb.SetActive(false);
            }
            DBManager.logedOut();
    
    
        }
    }`
