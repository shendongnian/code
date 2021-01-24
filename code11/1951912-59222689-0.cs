    private void OnTriggerEnter(Collider other)
        {
            Item temp = this.GetComponent<Item>();
            // This
            if (Inventory.invItems.Count < 12)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    // This
                    Inventory.AddToInventory(temp);
                    h.SetActive(false);
                }
            }
        }
