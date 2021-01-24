    public void MonsterDeath() //assumes this function is part of the monster's script
    {
        GetComponent<Collider>.enabled = false;
        ... existing code....
    }
