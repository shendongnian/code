    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class loadingcolorful : MonoBehaviour
    {
        public float speed = 0.0f;
        public bool fillAmount = false;
        public bool rotate = false;
        public bool changeRotationDir = false;
        public bool changeFillDir = false;
        public bool useBackGroundImage = true;
    
        private RectTransform rectTransform;
        private Image imageComp;
        private Image backGroundImage;
    
        // Use this for initialization
        void Start()
        {
            imageComp = GetComponent<RectTransform>().GetComponent<Image>();
            backGroundImage = transform.parent.gameObject.transform.GetComponent<Image>();
    
            UseBackgImage();
        }
    
        // Update is called once per frame
        void Update()
        {
            UseBackgImage(useBackGroundImage);
    
            if (fillAmount == true)
            {
                if (imageComp.fillAmount != 1f)
                {
                    if (changeFillDir == true)
                    {
                        if (imageComp.fillAmount == 0)
                        {
                            imageComp.fillAmount = 1f;
                        }
                        imageComp.fillAmount -= speed;
                    }
                    else
                    {
                        imageComp.fillAmount += speed;
                    }
                }
                else
                {
                    imageComp.fillAmount = 0f;
                }
            }
            else
            {
                if (imageComp.fillAmount == 0f)
                {
                    imageComp.fillAmount = 0f;
                }
                else
                {
                    imageComp.fillAmount = 1f;
                }
            }
    
            if (rotate == true)
            {
                if (changeRotationDir == true)
                {
                    rectTransform.Rotate(new Vector3(0, 0, -1));
                }
                else
                {
                    rectTransform.Rotate(new Vector3(0, 0, 1));
                }
            }
        }
    
        private void UseBackgImage()
        {
            if (useBackGroundImage == true)
            {
                backGroundImage.enabled = true;
                rectTransform = transform.parent.gameObject.transform.GetComponent<RectTransform>();
            }
            else
            {
                backGroundImage.enabled = false;
                rectTransform = transform.GetComponent<RectTransform>();
            }
        }
    
        private void UseBackgImage(bool UseBackGroundImage)
        {
            if (useBackGroundImage == true)
            {
                backGroundImage.enabled = true;
            }
            else
            {
                backGroundImage.enabled = false;
            }
        }
    }
