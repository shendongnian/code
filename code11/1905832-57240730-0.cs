    public class OvverrideImgCOntroller : MonoBehaviour {
       public Sprite[] SpritesArr;
       public Image Img;
       private int _vegPoint;
       private bool _UpgradeDone;
    
       void Update() {
           if (_UpgradeDone) {
               Img.overrideSprite = SpritesArr[++_vegPoint]; // or _vegpoint++ depended on your logic
               _UpgradeDone = false;//make this variable false to prevent upgrade method to execute this code multiply
           }       
       }
       //calling this method for example when UI button is clicked
       public void DoUpgrade() {
           _UpgradeDone = true;
       } 
    }
    
   
