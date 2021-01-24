    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = false;
        }
        else if (other.gameObject.tag == "Cyclist")
        {
            cyclistInside = false;
        }
        if (playerInside == false && cyclistInside == false) 
        {
            StartCoroutine(timedelay());
        }
    }
