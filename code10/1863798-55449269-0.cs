    bool canInput = true;
    foreach(Ability in Abilities)
    {
     if (Ability.IsSkillActive())
     {
      canInput = false; //still in the middle of an active ability
      break;
     }
    }
    if (canInput)
    {
     //Do allow player to have input here.
    }
