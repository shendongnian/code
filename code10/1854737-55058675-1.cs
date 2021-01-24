    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    //*************************Script to select one "Category(say Weapon)" UI Button till anathor category button(say Vehicles) is pressed.********************************//  
    
    /*
     * Steps to be followed to make this script work
     * Select All the Category Buttons (for example:- Suppose u r builiding a shop UI then Select all Category button Like Helics, Weapons  -- refer to video link above;
     * Now tag all these category button as same (say UI_CategoryButtons).
     * Attach this script to all the UI_category button.
     * the script will aotomatically add Button, Animator, Image component to the Ui Gameobjects.
     * now select Animation in Transition tab.
     * now press the Auto genrate Animation in Button component tab.
     * now, set Transition from Animation to none in button Tab.
     * Now, Do the above step for Sub category UI element too (for eg do for Apache, Tiger, f-22 etc which is the sub category of Helics --- refer video)
     * open Animation window and Animate ur Ui elements.
     * ur good to go now.
     */
    
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Image))]
    public class ButtonAnimationHold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public float TransitionTime = 0.3f;  //Time taken to transition from one animation state to anathor.
    
        private Animator MyAnim;      //reference to animator attacted to the UI gameObject.
    
        private void Start()
        {
            MyAnim = GetComponent<Animator>();
            PlayNoramlState();      //Playing normal state at beginning.
        }
    
        public void HighlightThisButton_UnhighlightRest()    //called when button is pressed (Called by OnPointerClick() defined below)
        {
            string TagOfPressedButton = gameObject.tag;  //the tag of the button pressed by user.
    
            foreach (Button button in gameObject.GetComponentInParent<Transform>().root.gameObject.GetComponentsInChildren<Button>())   //searching the gameobject with tag as in TagOfPressedButton inside the canvas which contain all UI element.
            {                                                                                                                           //we search inside Canvas to improve perf.
                if(button.gameObject.tag == TagOfPressedButton && button.gameObject != this.gameObject)     //selecting gameobjects with same tag(tag of button which was pressed) execpt the one which was pressed and then playing normal state in all selected GO.  
                {
                    button.gameObject.GetComponent<ButtonAnimationHold>().PlayNoramlState();       //Playing normal state in all UI gameObject with same tag except the one which called it.
                }
            }
    
            MyAnim.Play("Pressed");  //Playing Pressed state in the UI element that was pressed.
    
        }
    
        public void PlayNoramlState()
        {
            MyAnim.CrossFadeInFixedTime("Normal", TransitionTime);      //smoothly transitioning to Normal state; 
        }
    
        public void OnPointerEnter(PointerEventData eventData)      //Called when pointer hover over the Ui elemnt;
        {
            if(MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Normal"))      //Playing highlighted state only when it is in normal state and not when it is in Pressed state.
            {
                MyAnim.CrossFadeInFixedTime("Highlighted", TransitionTime);    //smoothly transitioning to Highlighted state; 
            }
        }
                
    
        public void OnPointerExit(PointerEventData eventData)  
        {
            if (MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Highlighted") || MyAnim.GetCurrentAnimatorStateInfo(0).IsName("Normal"))  //Playing Normal state only when it is in Highlighted state and not when it is in Pressed state
            {
                MyAnim.CrossFadeInFixedTime("Normal", TransitionTime);  //smoothly transitioning to Normal state; 
            }
        }
    
        public void OnPointerClick(PointerEventData eventData)   //called when button is pressed that is pointer down and pointer up both have to be done over button
        {
            HighlightThisButton_UnhighlightRest();
        }
    }
       
    
    //video link 
    //https://youtu.be/-H7j3vdKl8A
