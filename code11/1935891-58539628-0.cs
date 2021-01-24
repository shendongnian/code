        LayerMask layer = LayerMask.GetMask("Layer A", "Layer B", "Layer C");
        Interactable interactable = currentObject.GetComponent<Interactable>();
        for (int i = 0; i < 3; i++)
        {
            if (layer == (layer | (1 << interactable.gameObject.layer)))
                interactable.Pressed();
        }
