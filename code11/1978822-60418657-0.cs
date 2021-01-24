                case TouchPhase.Moved:
                    if (Physics.Raycast(raycast, out raycastHit))
                    {
                        if (raycastHit.collider.name == this.name)
                        {
                            Debug.Log("move " + " " + this.name);
                            transform.position = new Vector3(touchPos.x = deltaX, touchPos.y = deltaY, initialPosition.z);
                        }
                    }
                    break;
