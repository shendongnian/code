modelBuilder.Entity("Oganize.Api.Core.Entities.WishlistSpeakerTrack", b =>
                {
                    b.HasOne("Oganize.Api.Core.Entities.Track", "Track")
                        .WithMany("WishlistSpeakerTracks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                    b.HasOne("Oganize.Api.Core.Entities.WishlistSpeaker", "WishlistSpeaker")
                        .WithMany("WishlistSpeakerTracks")
                        .HasForeignKey("WishlistSpeakerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
