      void Start () {
            rectTransform = sliderWrapper.GetComponent<RectTransform> (); // parent wrapper
            currentItem = 0; // start x position of the wrapper
            itemWidth = 1000f; // width of the images
            itemCount = sliderWrapper.transform.childCount; // number of images
        }
