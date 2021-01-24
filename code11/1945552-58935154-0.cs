    float defaultZValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player2")
        {
            player.Health += Healing;
            Instantiate(Flame, new Vector3(player.GridPosition.x, player.GridPosition.y+1, defaultZValue), Quaternion.identity);
            Instantiate(Flame, new Vector3(player.GridPosition.x, player.GridPosition.y-1, defaultZValue), Quaternion.identity);
            Instantiate(Flame, new Vector3(player.GridPosition.x+1, player.GridPosition.y, defaultZValue), Quaternion.identity);
            Instantiate(Flame, new Vector3(player.GridPosition.x-1, player.GridPosition.y, defaultZValue), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
