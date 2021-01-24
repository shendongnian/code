           if (Input.GetKeyDown(KeyCode.E))
            {
                Box = Instantiate(Box, spawnpoint1.position, Quaternion.identity);
                boxRenderer = Box.transform.GetComponent<Renderer>();
                boxRenderer.material.color = boxColor;  //  change the color after it is instantiated
                actionSound.Play();
            }
