    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using System.IO;
    using System.Linq;
    
    public class PickUpItem : MonoBehaviour, IInteractable
    {
    
        public string DisplaySprite;
    
        public string DisplayImage;
    
        public static List<string> itemOrder = new List<string>();
    
        public static string ItemChoosenOrder;
    
        public static int counter;
    
        public static GameObject InventorySlots;
    
        public static GameObject[] PlayerItems = new GameObject[8];
    
        public void Interact(DisplayImage currentDisplay)
        {
            ItemPickUp();
        }
    
        void Start()
        {
            PlayerItems = GameObject.FindGameObjectsWithTag("ChoosenItem");
        }
    
        void Update()
        {
    
        }
    
        public void ItemPickUp()
        {
            InventorySlots = GameObject.Find("Slots");
    
            counter = 0;
    
            int j;
    
            foreach (Transform slot in InventorySlots.transform)
            {
                if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
                {
                    slot.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                    Destroy(gameObject);
                    break;
                }
    
    
                if (counter <= 7)
                {
                    //itemOrder.Add(PlayerItems[counter].GetComponent<Image>().sprite.name);
    
                    counter++;
    
    
                    if (counter >= 7)
                    {
    
                        {
                            PlayerItems = GameObject.FindGameObjectsWithTag("ChoosenItem");
    
                            Debug.Log("You have choosen all your items.");
    
                            foreach (Transform finalslot in InventorySlots.transform)
                            {
                                if (finalslot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
                                {
                                    finalslot.transform.GetChild(0).GetComponent<Image>().sprite =
                                        Resources.Load<Sprite>("Inventory Items/" + DisplaySprite);
                                    Destroy(gameObject);
                                    break;
                                }
                            }
    
                            itemOrder.Add(GameObject.Find("item0").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item1").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item2").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item3").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item4").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item5").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item6").GetComponent<Image>().sprite.name);
                            itemOrder.Add(GameObject.Find("item7").GetComponent<Image>().sprite.name);
    
    
                            //https://hub.packtpub.com/arrays-lists-dictionaries-unity-3d-game-development/
    
                            if (PlayerItems[7].GetComponent<Image>().sprite.name != "empty_item")
                            {
    
                                PlayerItems = GameObject.FindGameObjectsWithTag("ChoosenItem");
    
                                for (j = 0; j < 8; j++)
                                {
                                    Debug.LogFormat("Item[{0}] = {1}", j, itemOrder[j]);
                                }
    
                                ItemChoosenOrder = "1: " + itemOrder[0] + " 2: " + itemOrder[1]
                                + " 3: " + itemOrder[2] + " 4: " + itemOrder[3]
                                    + " 5: " + itemOrder[4] + " 6: " + itemOrder[5]
                                + " 7: " + itemOrder[6] + " 8: " + itemOrder[7];
    
                                Debug.Log(ItemChoosenOrder);
                            }
    
                            else
                            {
                                Debug.Log("Error choosing items");
                            }
    
    
                        }
    
    
                    }
    
    
                }
    
    
            }
    
        }
    
    }
