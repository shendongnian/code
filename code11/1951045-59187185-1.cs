    public class InfoButtonLoad : GameButton
    {
        public static InfoButtonLoad the;
        public bool isNext;
        [SerializeField] private GameObject[] infoSelect;
        public int infoSwitch;
        void Start()
        {
        }
        public override void PressAction()
        {
            if(isNext){
                infoSwitch++;
                if(infoSwitch == 5){
                    infoSwitch = 0;
                }
            }else{
                infoSwitch--;
                if(infoSwitch == 0){
                    infoSwitch = 4;
                }
            }
            InfoButtonCase();
        }
        public void InfoButtonCase()
        {
            foreach(GameObject info in infoSelect)
            {
                info.SetActive(false);
            }
            infoSelect[infoSwitch].SetActive(true);
            
        }
        void HideInfo()
        {
            for (var i = 0; i < infoSelect.Length; i++)
                infoSelect[i].SetActive(false);
        }
    }
