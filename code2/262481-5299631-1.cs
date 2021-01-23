    public void CopyTo(PlayerBO player) {
	player.Id = this.Id;
	player.Name = this.Name;
	player.CurrentPolicyVersion = this.CurrentPolicyVersion;
	player.CreatedAt = this.CreatedAt;
	player.UpdatedAt = this.UpdatedAt;
	player.Description = this.Description;
	player.MACAddress = this.MACAddress;
	player.IPAddress = this.IPAddress;
	player.Policy = Policy;
