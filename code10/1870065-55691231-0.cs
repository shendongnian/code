       public async Task<ReturnResult> DeleteUser(DeleteDto deleteDto, CancellationToken cancellationToken)
        {
            using (var db = new Db())
            {
                db.Users.Remove(new User() { Id = deleteDto.id });
                await db.SaveChangesAsync(cancellationToken);
            }
            return Ok();
        }
