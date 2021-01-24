    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    
    public class Slot : MonoBehaviour, IDragHandler, IDropHandler
    {
    
        public RectTransform Item_DragRect
        {
            get
            {
                if(Item_CS.Item_Dragged != null)
                {
                    return Item_CS.Item_Dragged.GetComponent<RectTransform>();
                }
                else
                {
                    return null;
                }
            }
        }
        public RectTransform rectTransform;
        public RectTransform rectParent;
        public Rect DisplayRect;
    
        public Color D_Color;
        public Color O_Color;
        public Color T_Color;
        public GameObject CurrItem;
    
        // Start is called before the first frame update
        void Start()
        {
            rectTransform = this.GetComponent<RectTransform>();
            if(GetComponentInParent<GridLayoutGroup>() != null)
            {
                rectParent = GetComponentInParent<GridLayoutGroup>().GetComponent<RectTransform>();
            }
            else
            {
                rectParent = null;
            }
            
        }
    
        // Update is called once per frame
        public void FixedUpdate()
        {
            DisplayRect = new Rect(rectTransform.transform.position.x, rectTransform.transform.position.y, rectTransform.rect.width, rectTransform.rect.height);
            if (Item_DragRect != null)
            {
                CurrItem = Item_DragRect.gameObject;
                if(rectParent != null)
                {
                    Rect myRect = new Rect(rectTransform.localPosition.x + rectParent.localPosition.x, rectTransform.localPosition.y + rectParent.localPosition.y, rectTransform.rect.width, rectTransform.rect.height);
                    Rect ItemRect = new Rect(Item_DragRect.localPosition.x, Item_DragRect.localPosition.y, Item_DragRect.rect.width, Item_DragRect.rect.height);
    
                    if (ItemRect.Overlaps(myRect))
                    {
                        GetComponent<Image>().color = O_Color;
                    }
                    else
                    {
                        GetComponent<Image>().color = D_Color;
                    }
                }
                else
                {
                    Rect myRect = new Rect(rectTransform.localPosition.x, rectTransform.localPosition.y, rectTransform.rect.width, rectTransform.rect.height);
                    Rect ItemRect = new Rect(Item_DragRect.localPosition.x, Item_DragRect.localPosition.y, Item_DragRect.rect.width, Item_DragRect.rect.height);
    
                    if (ItemRect.Overlaps(myRect))
                    {
                        GetComponent<Image>().color = O_Color;
                    }
                    else
                    {
                        GetComponent<Image>().color = D_Color;
                    }
                }
                
                
            }
            else
            {
                CurrItem = null;
                GetComponent<Image>().color = D_Color;
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            
        }
    
        public void OnDrop(PointerEventData eventData)
        {
            
        }
    }
