    using System.Threading;
    using UnityEngine;
    public class Manager : MonoBehaviour
    {
        EventWaitHandle handle = new EventWaitHandle(false,EventResetMode.AutoReset);
        Thread _thread;
        public void StartThread()
        {
            _thread = new Thread(BackgroundThreadFunction);
            _thread.Start();
        }
        public void BackgroundThreadFunction()
        {
            if (AskForTakingMoney())
            {
                //Yes
            }
            else
            {
                //No
            }
        }
        public bool AskForTakingMoney()
        {
            takingMoneyBox.SetActive(true);
            goldText.text = "Current Gold: " + GameManager.instance.currentGold.ToString() + "G";
            questionText.text = "Pay the " + DialogManager.instance.goldAmount + "G?";
            
            //Wait here until yes or no button pushed
            handle.WaitOne();
            
            return saysYes;
        }
        
        public void SaysYes()
        {
            saysYes = true;
            selectedAnswer = true;
            takingMoneyBox.SetActive(false);
            
            handle.Set();
        }
        
        public void SaysNo()
        {
            saysYes = false;
            selectedAnswer = true;
            takingMoneyBox.SetActive(false);
            
            handle.Set();
        }
    }
