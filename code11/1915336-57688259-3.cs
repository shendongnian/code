    private void Start()
    {
        foreach(var parent in objectsToNumber)
        {
            var newText = GetComponentInChildren<TextMesh>();
            if(!newText) newText = Instantiate(text).GetComponent<TextMesh>();
    
            renderer.Add(newText);
    
            switch(textPosition)
            {
                case TextPosition.Above:
                    newPos = parent.transform.position + Vector3.up * (renderer[i].bounds.extents.y + yPadding);
                    break;
    
                case TextPosition.InFront:
                    newPos = parent.transform.position + Vector3.up * (renderer[i].bounds.extents.x + yPadding);
                    break;
            }
    
            newText.transform.position = newPos;
            newText.transform.parent = parent.transform;
            newText.name = parent.name + " Text";
            newText.tag = "ObjectToAddText";
            newTexts.Add(newText);
        
            switch(textPosition)
            {
                case TextPosition.Above:
                    newText.text = renderer.Count.ToString();
                    break;
    
                case TextPosition.InFront:
                    newText.text = parent.name;
                    break;
            }
        }
    }
    
    and
    
        private void Update()
        {
            if (rotateNumbers)
            {
                foreach (var text in newTexts)
                {
                    // I would rather assign the correct value to rotationSpeed 
                    // instead of multiplying it by 10 afterwards ...
                    text.transform.Rotate(Vector3.up, 10 * rotationSpeed * Time.deltaTime);
                }
            }
        }
    }
