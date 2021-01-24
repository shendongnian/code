            }
        } 
    }
    if (Input.GetKeyUp(KeyCode.Mouse0) && cubeisClicked2)
    {
        cubeisClicked2 = false;
        trajectoryDots.SetActive(false);
        rb.velocity = new Vector3 (ShotForce.x, ShotForce.y, ShotForce.z);;
    }
